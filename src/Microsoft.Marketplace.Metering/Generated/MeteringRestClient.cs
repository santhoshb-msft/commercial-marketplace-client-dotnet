// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Marketplace.Metering.Models;

namespace Microsoft.Marketplace.Metering
{
    internal partial class MeteringRestClient
    {
        private Uri endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of MeteringRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public MeteringRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string apiVersion = "2018-08-31")
        {
            endpoint ??= new Uri("https://marketplaceapi.microsoft.com/api");
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            this.endpoint = endpoint;
            this.apiVersion = apiVersion;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreatePostUsageEventRequest(UsageEvent body, Guid? requestId, Guid? correlationId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/usageEvent", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (requestId != null)
            {
                request.Headers.Add("x-ms-requestid", requestId.Value);
            }
            if (correlationId != null)
            {
                request.Headers.Add("x-ms-correlationid", correlationId.Value);
            }
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(body);
            request.Content = content;
            return message;
        }

        /// <summary> Posts a single usage event to the marketplace metering service API. </summary>
        /// <param name="body"> The UsageEvent to use. </param>
        /// <param name="requestId"> A unique string value for tracking the request from the client, preferably a GUID. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="correlationId"> A unique string value for operation on the client. This parameter correlates all events from client operation with events on the server side. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public async Task<Response<UsageEventOkResponse>> PostUsageEventAsync(UsageEvent body, Guid? requestId = null, Guid? correlationId = null, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreatePostUsageEventRequest(body, requestId, correlationId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        UsageEventOkResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = UsageEventOkResponse.DeserializeUsageEventOkResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Posts a single usage event to the marketplace metering service API. </summary>
        /// <param name="body"> The UsageEvent to use. </param>
        /// <param name="requestId"> A unique string value for tracking the request from the client, preferably a GUID. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="correlationId"> A unique string value for operation on the client. This parameter correlates all events from client operation with events on the server side. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public Response<UsageEventOkResponse> PostUsageEvent(UsageEvent body, Guid? requestId = null, Guid? correlationId = null, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreatePostUsageEventRequest(body, requestId, correlationId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        UsageEventOkResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = UsageEventOkResponse.DeserializeUsageEventOkResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostBatchUsageEventRequest(BatchUsageEvent body, Guid? requestId, Guid? correlationId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/batchUsageEvent", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (requestId != null)
            {
                request.Headers.Add("x-ms-requestid", requestId.Value);
            }
            if (correlationId != null)
            {
                request.Headers.Add("x-ms-correlationid", correlationId.Value);
            }
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(body);
            request.Content = content;
            return message;
        }

        /// <summary> The batch usage event API allows you to emit usage events for more than one purchased entity at once. The batch usage event request references the metering services dimension defined by the publisher when publishing the offer. </summary>
        /// <param name="body"> The BatchUsageEvent to use. </param>
        /// <param name="requestId"> A unique string value for tracking the request from the client, preferably a GUID. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="correlationId"> A unique string value for operation on the client. This parameter correlates all events from client operation with events on the server side. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public async Task<Response<BatchUsageEventOkResponse>> PostBatchUsageEventAsync(BatchUsageEvent body, Guid? requestId = null, Guid? correlationId = null, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreatePostBatchUsageEventRequest(body, requestId, correlationId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BatchUsageEventOkResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = BatchUsageEventOkResponse.DeserializeBatchUsageEventOkResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> The batch usage event API allows you to emit usage events for more than one purchased entity at once. The batch usage event request references the metering services dimension defined by the publisher when publishing the offer. </summary>
        /// <param name="body"> The BatchUsageEvent to use. </param>
        /// <param name="requestId"> A unique string value for tracking the request from the client, preferably a GUID. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="correlationId"> A unique string value for operation on the client. This parameter correlates all events from client operation with events on the server side. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public Response<BatchUsageEventOkResponse> PostBatchUsageEvent(BatchUsageEvent body, Guid? requestId = null, Guid? correlationId = null, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreatePostBatchUsageEventRequest(body, requestId, correlationId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BatchUsageEventOkResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = BatchUsageEventOkResponse.DeserializeBatchUsageEventOkResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUsageEventRequest(DateTimeOffset usageStartDate, DateTimeOffset? usageEndDate, string offerId, string planId, string dimension, Guid? azureSubscriptionId, ReconStatusEnum? reconStatus, Guid? requestId, Guid? correlationId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/usageEvents", false);
            uri.AppendQuery("api-version", apiVersion, true);
            uri.AppendQuery("usageStartDate", usageStartDate, "O", true);
            if (usageEndDate != null)
            {
                uri.AppendQuery("UsageEndDate", usageEndDate.Value, "O", true);
            }
            if (offerId != null)
            {
                uri.AppendQuery("offerId", offerId, true);
            }
            if (planId != null)
            {
                uri.AppendQuery("planId", planId, true);
            }
            if (dimension != null)
            {
                uri.AppendQuery("dimension", dimension, true);
            }
            if (azureSubscriptionId != null)
            {
                uri.AppendQuery("azureSubscriptionId", azureSubscriptionId.Value, true);
            }
            if (reconStatus != null)
            {
                uri.AppendQuery("reconStatus", reconStatus.Value.ToSerialString(), true);
            }
            request.Uri = uri;
            if (requestId != null)
            {
                request.Headers.Add("x-ms-requestid", requestId.Value);
            }
            if (correlationId != null)
            {
                request.Headers.Add("x-ms-correlationid", correlationId.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> You can call the usage events API to get the list of usage events. </summary>
        /// <param name="usageStartDate"> DateTime in ISO8601 format. For example, 2020-12-03T15:00 or 2020-12-03. </param>
        /// <param name="usageEndDate"> DateTime in ISO8601 format. Default = current date. </param>
        /// <param name="offerId"> OfferId. </param>
        /// <param name="planId"> PlanId. </param>
        /// <param name="dimension"> DimensionId. </param>
        /// <param name="azureSubscriptionId"> Azure Subscription Id. </param>
        /// <param name="reconStatus"> Recon Status. </param>
        /// <param name="requestId"> A unique string value for tracking the request from the client, preferably a GUID. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="correlationId"> A unique string value for operation on the client. This parameter correlates all events from client operation with events on the server side. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<GetUsageEventOkResponse>> GetUsageEventAsync(DateTimeOffset usageStartDate, DateTimeOffset? usageEndDate = null, string offerId = null, string planId = null, string dimension = null, Guid? azureSubscriptionId = null, ReconStatusEnum? reconStatus = null, Guid? requestId = null, Guid? correlationId = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUsageEventRequest(usageStartDate, usageEndDate, offerId, planId, dimension, azureSubscriptionId, reconStatus, requestId, correlationId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        GetUsageEventOkResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = GetUsageEventOkResponse.DeserializeGetUsageEventOkResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> You can call the usage events API to get the list of usage events. </summary>
        /// <param name="usageStartDate"> DateTime in ISO8601 format. For example, 2020-12-03T15:00 or 2020-12-03. </param>
        /// <param name="usageEndDate"> DateTime in ISO8601 format. Default = current date. </param>
        /// <param name="offerId"> OfferId. </param>
        /// <param name="planId"> PlanId. </param>
        /// <param name="dimension"> DimensionId. </param>
        /// <param name="azureSubscriptionId"> Azure Subscription Id. </param>
        /// <param name="reconStatus"> Recon Status. </param>
        /// <param name="requestId"> A unique string value for tracking the request from the client, preferably a GUID. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="correlationId"> A unique string value for operation on the client. This parameter correlates all events from client operation with events on the server side. If this value isn&apos;t provided, one will be generated and provided in the response headers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<GetUsageEventOkResponse> GetUsageEvent(DateTimeOffset usageStartDate, DateTimeOffset? usageEndDate = null, string offerId = null, string planId = null, string dimension = null, Guid? azureSubscriptionId = null, ReconStatusEnum? reconStatus = null, Guid? requestId = null, Guid? correlationId = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUsageEventRequest(usageStartDate, usageEndDate, offerId, planId, dimension, azureSubscriptionId, reconStatus, requestId, correlationId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        GetUsageEventOkResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = GetUsageEventOkResponse.DeserializeGetUsageEventOkResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
