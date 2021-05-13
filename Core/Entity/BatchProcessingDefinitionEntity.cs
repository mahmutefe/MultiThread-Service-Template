namespace BatchProcessing.Core.Entity
{
    public class BatchProcessingDefinitionEntity
    {
        public int FileReaderThreadCount { get; set; }
        public int PendingTransactionReaderThreadCount { get; set; }
    }
}
