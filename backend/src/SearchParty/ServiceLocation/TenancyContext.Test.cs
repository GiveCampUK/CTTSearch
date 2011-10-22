namespace SearchParty.Api.ServiceLocation
{
    using global::System;
    using NFeature;
    using Tenant = Core.Tenant;

    public class TenancyContext : ITenancyContext<Tenant>
    {
        public Tenant CurrentTenant
        {
            get { return Tenant.All; }
        }
    }
}