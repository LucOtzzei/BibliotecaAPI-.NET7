﻿using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Responses
{
    public class PublishingCompanyResponse
    {
        public PublishingCompanyResponse(PublishingCompany pb)
        {
            Name = pb.Name;
        }
        public PublishingCompanyResponse(PublishingCompanyRequest request)
        {
            Name = request.Name;
        }
        public string Name { get; set; }
    }
}