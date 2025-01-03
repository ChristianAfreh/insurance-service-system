namespace InsuranceServiceApp.Utility
{
    public static class AppHttpContext
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current
        {
            get
            {
                if (_httpContextAccessor == null)
                {
                    throw new InvalidOperationException("HttpContextAccessor is not configured. Please call Configure() during application startup.");
                }

                return _httpContextAccessor.HttpContext;
            }
        }

        public static string AppBaseUrl
        {
            get
            {
                var request = Current?.Request;
                if (request == null)
                {
                    throw new InvalidOperationException("HttpContext is not available.");
                }

                return $"{request.Scheme}://{request.Host}{request.PathBase}";
            }
        }
    }

}
