using UrlShortener.Services.Abstractions;
using UrlShortener.Persistence.Contexts;
using UrlShortener.Domain.Utils;
using System.Text;

namespace UrlShortener.Services;
public class LinkService : ILinkService
{
    private readonly LinksContext context;
    private static char[] CHARACTERS = new char[62] {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        '0', '1', '2', '3', '4', '5', '6','7', '8', '9' };

    public LinkService(LinksContext context)
    {
        this.context = context;
    }

    public void CreateLink(string destination)
    {
        string alias = buildAlias();

        // Todo: Perform a check to compare with the database if the alias already exists.
        throw new NotImplementedException();
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
