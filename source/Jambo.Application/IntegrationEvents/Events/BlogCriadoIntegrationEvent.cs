using Jambo.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Application.IntegrationEvents.Events
{
    public class BlogCriadoIntegrationEvent : IntegrationEvent, IRequest
    {
        public string Url { get; set; }

        public BlogCriadoIntegrationEvent(string url)
        {

        }
    }
}
