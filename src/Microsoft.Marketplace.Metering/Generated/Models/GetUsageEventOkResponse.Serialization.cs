// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Microsoft.Marketplace.Metering.Models
{
    public partial class GetUsageEventOkResponse
    {
        internal static GetUsageEventOkResponse DeserializeGetUsageEventOkResponse(JsonElement element)
        {
            Optional<IReadOnlyList<GetUsageEvent>> request = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("request"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<GetUsageEvent> array = new List<GetUsageEvent>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(GetUsageEvent.DeserializeGetUsageEvent(item));
                    }
                    request = array;
                    continue;
                }
            }
            return new GetUsageEventOkResponse(Optional.ToList(request));
        }
    }
}
