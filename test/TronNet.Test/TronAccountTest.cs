using Microsoft.Extensions.DependencyInjection;
using TronNet.Crypto;
using TronNet.Protocol;
using Xunit;

namespace TronNet.Test
{
    public class TronAccountTest
    {
        private readonly TronTestRecord _record;
        private readonly WalletSolidity.WalletSolidityClient _wallet;
        private readonly IWalletClient _walletClient;

        public TronAccountTest()
        {
            _record = TronTestServiceExtension.GetTestRecord();

            //_wallet = _record.TronClient.GetWallet();

            _wallet = _record.TronClient.GetWallet().GetSolidityProtocol();

            _walletClient = _record.ServiceProvider.GetService<IWalletClient>();
        }

        [Fact]
        public void GetAccount_ShouldReturnAccountInfo()
        {

            var testTxId = BytesMessage.Descriptor.Parser.ParseJson("{ \"value\": \"c288074e2cb46f70be2856e9ac8479138014ac414ddb5aa7e8c3e77811d812d1\"}");

            var trxId = BytesMessage.Parser.ParseJson("{ \"value\": \"9d130d40a5406cde27ac1e60acfee4a375c1aaeb02f983f581c0bef7823eabd2\"}");

            var transaction = _wallet.GetTransactionById(trxId);

            var address = Google.Protobuf.ByteString.CopyFrom(Base58Encoder.DecodeFromBase58Check("TLDEyvVXT5DuwhvA3FVndnQgiyALicpEJ5"));

            var a = _wallet.GetAccount(new Account() { Address = address });
        }
    }
}
