namespace code_gen_web_api
{
    public partial class EndpointBuilder
    {
        public static void Build(WebApplication app)
        {
            BuildEndpoints(app);
        }

        static partial void BuildEndpoints(WebApplication app);
    }
}
