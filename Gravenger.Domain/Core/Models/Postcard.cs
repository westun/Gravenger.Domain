using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gravenger.Domain.Core.Models
{
    public class Postcard
    {
        private const int TilesRequiredToComplete = 9;

        public Postcard()
        {
            this.AccountTiles = new Collection<AccountTile>();
            this.PostcardLikes = new Collection<PostcardLike>();
        }

        public int PostcardID { get; set; }
        public int AccountID { get; set; }
        public int CardID { get; set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset? CompletedDate { get; private set; }

        public Account Account { get; set; }
        public virtual ICollection<AccountTile> AccountTiles { get; set; }
        public Card Card { get; set; }
        public virtual ICollection<PostcardLike> PostcardLikes { get; set; }

        public bool IsMarkedCompleted
        {
            get
            {
                return this.CompletedDate.HasValue;
            }
        }

        public bool TryMarkCompleted()
        {
            if (!this.IsMarkedCompleted && this.HasCompletedAllTiles)
            {
                this.MarkCompleted();
                return true;
            }
            return false;
        }

        private bool HasCompletedAllTiles
        {
            get
            {
                return this.AccountTiles.Count == TilesRequiredToComplete;
            }
        }

        private void MarkCompleted()
        {
            this.CompletedDate = DateTimeOffset.UtcNow;
        }
    }
}
