﻿using System.Collections.Generic;
using OpenRasta.Codecs;
using OpenRasta.Configuration;
using Paramore.Adapters.Presentation.API.Contributors;
using Paramore.Adapters.Presentation.API.Handlers;
using Paramore.Adapters.Presentation.API.Resources;
using Paramore.Domain.Venues;

namespace Paramore.Adapters.Presentation.API
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Uses.PipelineContributor<DependencyPipelineContributor>();

                //Resources
                ResourceSpace.Has.ResourcesOfType<EntryPointResource>()
                    .AtUri("/entrypoint")
                    .HandledBy<EntryPointHandler>()
                   .AsXmlDataContract().ForMediaType("application/vnd.paramore.data+xml").ForExtension("xml")
                    .And.AsJsonDataContract().ForMediaType("application/vnd.paramore.data+json;q=1").ForExtension("js").ForExtension("json");


                ResourceSpace.Has.ResourcesOfType<List<VenueResource>>()
                    .AtUri("/venues")
                    .HandledBy<VenueEndPointHandler>()
                    .TranscodedBy<XmlSerializerCodec>().ForMediaType("application/vnd.paramore.data+xml").ForExtension("xml")
                    .And.AsJsonDataContract().ForMediaType("application/vnd.paramore.data+json;q=1").ForExtension("js").ForExtension("json");

            }
        }

    }
}