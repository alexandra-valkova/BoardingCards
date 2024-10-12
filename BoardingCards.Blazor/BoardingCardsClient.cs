using System.Text.Json;

namespace BoardingCards.Blazor
{
    public class BoardingCardsClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public BoardingCardsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _jsonOptions = new()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<string?> GetBoardingCardsSummaryAsync(List<BoardingCard> boardingCards)
        {
            using HttpResponseMessage response = await _httpClient.PostAsJsonAsync("summary", boardingCards, _jsonOptions);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
