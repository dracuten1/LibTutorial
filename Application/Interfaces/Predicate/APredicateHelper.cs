using System;
using System.Linq.Expressions;

namespace Application.Interfaces.Predicate {
    public abstract class APredicateHelper<Request> {
        protected Expression<Func<Request, bool>> predicate = (a=>true);
        public Expression<Func<Request, bool>> Predicate() {
            return predicate;
        }
    }
}