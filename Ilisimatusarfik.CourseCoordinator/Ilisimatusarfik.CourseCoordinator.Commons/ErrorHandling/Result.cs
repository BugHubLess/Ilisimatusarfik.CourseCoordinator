namespace Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling
{
    using System;
    using E = Error;

    public static class Builder
    {
        public static Result<S>.Success CreateSuccess<S>(S item)
        {
            return new Result<S>.Success(item);
        }

        public static Result.Success CreateSuccess()
        {
            return new Result.Success();
        }

        public static Result<S>.Error CreateError<S>(S item, E error)
        {
            return new Result<S>.Error(error);
        }

        public static Result.Error CreateError(E error)
        {
            return new Result.Error(error);
        }
    }

    public abstract class Result<S>
    {
        public abstract T Match<T>(Func<S, T> success, Func<E, T> failure);

        public abstract void Match(Action<S> success, Action<E> failure);

        // private ctor ensures no external classes can inherit
        internal Result() { }

        public sealed class Success : Result<S>
        {
            private readonly S item;

            internal Success(S item)
            {
                this.item = item;
            }

            public override T Match<T>(Func<S, T> success, Func<E, T> failure) => success(item);

            public override void Match(Action<S> success, Action<E> failure) => success(item);
        }

        public sealed class Error : Result<S>
        {
            private readonly E item;

            internal Error(E item)
            {
                this.item = item;
            }

            public override T Match<T>(Func<S, T> success, Func<E, T> failure) => failure(item);

            public override void Match(Action<S> success, Action<E> failure) => failure(item);
        }
    }

    public abstract class Result
    {
        public abstract T Match<T>(Func<T> success, Func<E, T> failure);

        public abstract void Match(Action success, Action<E> failure);

        internal Result()
        {
        }

        public sealed class Success : Result
        {
            internal Success()
            {
            }

            public override T Match<T>(Func<T> success, Func<E, T> failure) => success();

            public override void Match(Action success, Action<E> failure) => success();
        }

        public sealed class Error : Result
        {
            public readonly E Item;

            public Error(E item)
            {
                Item = item;
            }

            public override T Match<T>(Func<T> success, Func<E, T> failure) => failure(Item);

            public override void Match(Action success, Action<E> failure) => failure(Item);
        }
    }
}