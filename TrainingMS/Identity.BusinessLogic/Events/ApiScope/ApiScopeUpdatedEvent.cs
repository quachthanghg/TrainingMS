using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.ApiScope
{
    public class ApiScopeUpdatedEvent : AuditEvent
    {
        public ApiScopeDto OriginalApiScope { get; set; }
        public ApiScopeDto ApiScope { get; set; }

        public ApiScopeUpdatedEvent(ApiScopeDto originalApiScope, ApiScopeDto apiScope)
        {
            OriginalApiScope = originalApiScope;
            ApiScope = apiScope;
        }
    }
}