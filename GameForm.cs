using System;

namespace eseFunzioniBasket
{
    internal class GameForm
    {
        private string nickname;

        public GameForm(string nickname)
        {
            this.nickname = nickname;
        }

        public int Score { get; internal set; }

        internal void ShowDialog() => throw new NotImplementedException();
    }
}