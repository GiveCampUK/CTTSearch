namespace SearchParty.Core
{
    using NFeature;

    public class TenancyContext : ITenancyContext<Tenant>
    {
        public Tenant CurrentTenant
        {
            get { return Tenant.All; }
        }
    }
}