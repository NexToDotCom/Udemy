using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<Activity>>> {}

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext context;
            public Handler(DataContext context, ILogger<List> logger)
            {
                this.context = context;                    
            }

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {       
                return Result<List<Activity>>.Success(await context.Activities.ToListAsync());
            }
        }
    }
}