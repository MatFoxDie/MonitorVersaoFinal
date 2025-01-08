string url = "https://jornaldebrasilia.com.br/feed/";

using (HttpClient client = new HttpClient())
{
    try
    {
        // Adiciona o cabeçalho User-Agent
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

        // Envia a requisição GET
        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        // Lê o conteúdo da resposta
        string responseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseBody);
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine($"Erro na requisição: {e.Message}");
    }
}