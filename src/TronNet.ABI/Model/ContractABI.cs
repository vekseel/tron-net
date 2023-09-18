namespace TronNet.ABI.Model
{
    public class ContractABI
    {
        public FunctionABI[] Functions { get; set; }
        public ConstructorABI Constructor { get; set; }
        public EventABI[] Events { get; set; }
    }
}