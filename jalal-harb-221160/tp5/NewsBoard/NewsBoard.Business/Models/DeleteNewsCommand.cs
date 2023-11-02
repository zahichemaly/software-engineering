﻿using MediatR;
using NewsBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Models
{
    public class DeleteNewsCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
