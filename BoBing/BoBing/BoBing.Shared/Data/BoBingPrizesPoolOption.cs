using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingPrizesPoolOption
    {
        private readonly int award1Count;
        private readonly int award2Count;
        private readonly int award3Count;
        private readonly int award4Count;
        private readonly int award5Count;
        private readonly int award6Count;

        public int Award1Count => award1Count;
        public int Award2Count => award2Count;
        public int Award3Count => award3Count;
        public int Award4Count => award4Count;
        public int Award5Count => award5Count;
        public int Award6Count => award6Count;

        /// <summary>
        /// 奖池设置
        /// </summary>
        /// <param name="award1Count">一秀个数</param>
        /// <param name="award2Count">二举个数</param>
        /// <param name="award3Count">四进个数</param>
        /// <param name="award4Count">三红个数</param>
        /// <param name="award5Count">对堂个数</param>
        /// <param name="award6Count">状元个数</param>
        public BoBingPrizesPoolOption(int award1Count, int award2Count, int award3Count, int award4Count, int award5Count, int award6Count)
        {
            this.award1Count = award1Count;
            this.award2Count = award2Count;
            this.award3Count = award3Count;
            this.award4Count = award4Count;
            this.award5Count = award5Count;
            this.award6Count = award6Count;
        }
    }
}
