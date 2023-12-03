using Stripe;
using Stripe.Checkout;

namespace BlazorEcommerce.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;
        private readonly IConfiguration _configuration;

        //Remeber to chech every 90 days
        const string stripeWebhookSecretKey = "whsec_b7399a42493cb8a0d4905f213cdfc8e6600339130db386b332429a67dab0ee98";

        public PaymentService(ICartService cartService, IAuthService authService, IOrderService orderService, IConfiguration configuration)
        {
            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
            _configuration = configuration;

            StripeConfiguration.ApiKey = _configuration.GetSection("AppSettings:StripeSecretKey").Value;
        }
        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetCartProductsFromDb()).Data;

            var lineItems = new List<SessionLineItemOptions>();

            products.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "eur",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.ImageUrl}
                    }
                },
                Quantity = product.Quantity
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions { AllowedCountries = new List<string> { "BA", "US", "GB" } },
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7076/order-success",
                CancelUrl = "https://localhost:7076/cart"
            };

            var sessionService = new SessionService();
            Session session = sessionService.Create(options);

            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        request.Headers["Stripe-Signature"],
                        stripeWebhookSecretKey
                    );

                if(stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = e.Message };
            }
        }
    }
}
