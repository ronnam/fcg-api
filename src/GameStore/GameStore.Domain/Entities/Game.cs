using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; private set; }
        public required string Title { get; init; }
        public required string Category { get; init; }

        private Game() { }

        [SetsRequiredMembers]
        private Game(string title, string category)
        {
            Id = Guid.NewGuid();
            Title = title;
            Category = category;
        }

        public static Game Create(string title, string category)
        {
            Validate(title, category);

            return new Game(title, category);
        }

        private static void Validate(string title, string category)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required.");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category is required.");

        }
    }
}