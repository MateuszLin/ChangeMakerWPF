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
            for (int i = 0; i < greedyResult.Count; i++)
            {
                if(greedyResult[i] != 0)
                {
                    output += $"{coinsTable.ElementAt(i)} -> {greedyResult[i]} {Environment.NewLine}";
                }
            }

            return output;

        }
    }
}
