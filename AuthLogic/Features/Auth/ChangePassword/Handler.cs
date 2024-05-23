using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthDB;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace AuthLogic.Features.Auth.ChangePassword;

public class Handler
(
    AppDbContext db
) : IRequestHandler<Request>
{
    public async ValueTask<Unit> Handle(Request request, CancellationToken cancellationToken)
    {
        await db.Set<AuthDB.Entities.User>()
            .Where(m => m.Id == request.UserId)
            .ExecuteUpdateAsync(s => s.SetProperty(m => m.Password, BCrypt.Net.BCrypt.HashPassword(request.Password)));

        return Unit.Value;
    }
}