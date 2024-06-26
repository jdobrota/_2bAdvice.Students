﻿using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace _2bAdvice.Students;

[Dependency(ReplaceServices = true)]
public class StudentsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Students";
}
