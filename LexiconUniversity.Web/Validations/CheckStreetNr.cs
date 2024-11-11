using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace LexiconUniversity.Web.Validations
{
    public class CheckStreetNr : ValidationAttribute
    {
        private readonly int max;

        public CheckStreetNr(int max)
        {
            this.max = max;
        }

        public override bool IsValid(object? value)
        {
            if(value is string input)
            {
                var num = input.Trim().Split().Last();
                return int.TryParse(num, out int res) & res <= max;
            }
            return false; 
        }
    }
}
