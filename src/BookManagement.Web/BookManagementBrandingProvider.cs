﻿using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace BookManagement.Web
{
    [Dependency(ReplaceServices = true)]
    public class BookManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BookManagement";
    }
}
