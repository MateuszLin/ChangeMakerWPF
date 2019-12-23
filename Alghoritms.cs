using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    public class Alghoritms
    {
        IEnumerable<int> coinsTable;
        int amount;
        private List<int> retList;

        public IList<int> GreedyAlghoritm(IEnumerable<int> coins, int amount, IList<int> retTable)
        {
            int temp = amount;
            int index = coins.Count() - 1;

            while(temp > 0)
            {
                if(temp >= coins.ElementAt(index))
                {
                    temp -= coins.ElementAt(index);
                    ++retTable[index];
                }
                else
                {
                    --index;
                }
            }

            return retTable;
        }

        public Tuple<int[], int[]> DynamicAlghoritm(IEnumerable<int> coins, int amount)
        {
            int[] coinsCounter = new int[amount + 1];
            int[] coinsIndex = new int[amount + 1];

            coinsCounter[0] = coinsIndex[0] = 0;

            for (int i = 1; i <= amount; i++)
            {
                int opt = 0;

                for (int j = 1; j < coins.Count(); j++)
                {

                    if(coins.ElementAt(j) <= i && (coinsCounter[i - coins.ElementAt(j)] <= coinsCounter[i - coins.ElementAt(opt)]))
                    {
                        opt = j;
                    }
                }

                coinsCounter[i] = coinsCounter[i - coins.ElementAt(opt)] + 1;

                coinsIndex[i] = opt;
            }

            return new Tuple<int[], int[]>(coinsCounter, coinsIndex);
        }

        internal void PrepareParameters(string coins, string amount)
        {
            if (coins is null)
            {
                throw new ArgumentNullException(nameof(coins));
            }

            if (amount is null)
            {
                throw new ArgumentNullException(nameof(amount));
            }

            coinsTable = coins.Split(' ').Select(int.Parse).Cast<int>();
            this.amount = Convert.ToInt32(amount);
            retList = new List<int>();

            for (int i = 0; i < coinsTable.Count(); i++)
            {
                retList.Add(0);
            }
        }

        public string CallGreedyAlghortim()
        {
            var greedyResult = GreedyAlghoritm(coinsTable, this.amount, new List<int>(retList));

            string output = string.Empty;
            for (int i = greedyResult.Count - 1; i >= 0 ; i--)
            {
                if(greedyResult[i] != 0)
                {
                    output += AddToOutput(coinsTable.ElementAt(i), greedyResult[i]);
                }
            }

            return output;

        }

        public string CallDynamicAlghoritm()
        {
            var dynamicResult = DynamicAlghoritm(coinsTable, amount);

            string output = string.Empty;
            Dictionary<int, int> coinCount = new Dictionary<int, int>();

            while(amount > 0)
            {
                var coin = coinsTable.ElementAt(dynamicResult.Item2[amount]);
                amount -= coin;

                if (coinCount.Keys.Contains(coin))
                    coinCount[coin]++;
                else
                    coinCount[coin] = 1;
            }

            foreach (var item in coinCount.Keys)
            {
                output += AddToOutput(item, coinCount[item]);
            }

            return output;
        }


        private string AddToOutput(int item, int value)
        {
            return $"{item} x {value} {Environment.NewLine}";
        }
    }
}
