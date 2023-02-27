namespace Code.Core.AI
{
    public class AICommand
    {
        public static readonly AICommand  START_RECORD = new AICommand("start_record");
        public static readonly AICommand  STOP_RECORD = new AICommand("stop_record");
        public static readonly AICommand  GET_DATA = new AICommand("get_data");

        public string Payload { get; }

        AICommand(string Payload)
        {
            this.Payload = Payload;
        }
        
    }
}