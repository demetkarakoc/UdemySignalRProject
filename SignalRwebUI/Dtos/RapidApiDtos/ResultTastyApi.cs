namespace SignalRwebUI.Dtos.RapidApiDtos
{
    public class RootTastyApi
    {
        public List<ResultTastyApi> Results { get; set; }
    }
	public class ResultTastyApi
	{
        public string Name { get; set; }
        public string video_url { get; set; }
        public string thumbnail_url { get; set; }
		public object Results { get; internal set; }
	}
}
