using System.Net.Http;
using System.Threading.Tasks;

public class WWWMgr
{
    public async Task<long> GetFileSizeAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.Headers.ContentLength ?? 0;
            }
            else
            {
                throw new Exception("Failed to get file size. HTTP " + response.StatusCode);
            }
        }
    }
}