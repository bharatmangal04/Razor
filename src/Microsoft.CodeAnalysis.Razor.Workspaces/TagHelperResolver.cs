﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Host;

namespace Microsoft.CodeAnalysis.Razor
{
    internal abstract class TagHelperResolver : ILanguageService
    {
        public abstract TagHelperResolutionResult GetTagHelpers(Compilation compilation, IEnumerable<string> assemblyNameFilters);

        public virtual async Task<TagHelperResolutionResult> GetTagHelpersAsync(
            Project project,
            IEnumerable<string> assemblyNameFilters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var compilation = await project.GetCompilationAsync(cancellationToken).ConfigureAwait(false);
            return GetTagHelpers(compilation, assemblyNameFilters);
        }
    }
}
