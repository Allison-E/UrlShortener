﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Utils;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.RequestHandlers.Links.Commands.Create;
public class CreateLinkCommand: IRequest<string>
{
    public string Destination { get; set; }
    public string Title { get; set; }

    public class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, string>
    {
        private static char[] CHARACTERS = new char[62] {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        '0', '1', '2', '3', '4', '5', '6','7', '8', '9' };

        private ILinksRepo repo;

        public CreateLinkCommandHandler(IRepoManager repoManager)
        {
            repo = repoManager.LinksRepo;
        }
        public Task<string> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            string alias = buildAlias();
            Link link = new()
            {
                Alias = alias,
                Destination = request.Destination,
                Title = request.Title,
            };
            repo.SaveLink(link);
            return null;
        }

        private string buildAlias()
        {
            const int lengthOfString = 8;
            StringBuilder builder = new();
            
            for (int i = 0; i < lengthOfString; i++)
            {
                var randomInt = Utility.GenerateRandomInt(CHARACTERS.Length);
                builder.Append(CHARACTERS[randomInt]);
            }

            return builder.ToString();
        }
    }
}
