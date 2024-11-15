using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Builders
{
    public class Review
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string ReviewText { get; set; }
    }

    public class ReviewBuilder
    {
        private Review review;

        public ReviewBuilder()
        {
            review = new Review();
        }

        public ReviewBuilder WithName(string name)
        {
            review.Name = name;
            return this;
        }

        public ReviewBuilder WithEmailAddress(string emailAddress)
        {
            review.EmailAddress = emailAddress;
            return this;
        }

        public ReviewBuilder WithReviewText(string reviewText)
        {
            review.ReviewText = reviewText;
            return this;
        }

        public Review Build()
        {
            return review;
        }
    }

}
