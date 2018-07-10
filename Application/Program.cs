using Nethereum.JsonRpc.Client;
using Nethereum.Web3;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {

        static decimal balance;

        static void Main(string[] args)
        {
            // Call an async function to set the balance and Wait on it to return
            getEthBalance().Wait();

            // Print the balance once the getEthBalance() function returns
            System.Diagnostics.Debug.Write("Account Balance: " + balance + " ether \n");
        }

        static async Task getEthBalance() 
        {
            // Encode App Credentials as <username>:<password>
            var byteArray = Encoding.ASCII.GetBytes("u0hy7mtdq3:mD29RPL7yEpwZqnqKPHGHbkdMoOAbUMO2JnUGYwO2LI");
            AuthenticationHeaderValue auth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            // Create the RPC Client to talk to the Kaleido endpoint using web3
            IClient client = new RpcClient(new Uri("https://u0p56k3t54-u0p9sxe7c1-rpc.us-east-2.kaleido.io"), auth, null, null, null);
            var web3 = new Web3(client);

            // Get the account balance of my account
            var some = await web3.Eth.GetBalance.SendRequestAsync("0x03374797eF307f9BCB303DE14008C76441193Fd2");

            // Set variable for use in other places
            balance = Web3.Convert.FromWei(some.Value);
        }
    }
}
