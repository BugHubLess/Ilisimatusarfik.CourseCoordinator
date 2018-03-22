namespace Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling
{
    using System;
    using E = Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling.Error;

    public abstract class Result<S>
    {
        public abstract bool IsSuccess { get; }

        public abstract T Match<T>(Func<S, T> success, Func<E, T> failure);

        public abstract void Match(Action<S> success, Action<E> failure);

        // private ctor ensures no external classes can inherit
        internal Result() { }

        public sealed class Success : Result<S>
        {
            public readonly S Item;

            public Success(S item)
            {
                Item = item;
            }

            public override bool IsSuccess => true;
            public override T Match<T>(Func<S, T> success, Func<E, T> failure) => success(Item);
            public override void Match(Action<S> success, Action<E> failure) => success(Item);
        }

        public sealed class Error : Result<S>
        {
            public readonly E Item;

            public Error(E item)
            {
                Item = item;
            }

            public override bool IsSuccess => false;
            public override T Match<T>(Func<S, T> success, Func<E, T> failure) => failure(Item);
            public override void Match(Action<S> success, Action<E> failure) => failure(Item);
        }
    }

    public abstract class Result
    {
        public abstract bool IsSuccess { get; }
        public abstract T Match<T>(Func<T> success, Func<E, T> failure);
        public abstract void Match(Action success, Action<E> failure);

        internal Result() { }

        public sealed class Success : Result
        {
            public override bool IsSuccess => true;
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

            public override bool IsSuccess => false;
            public override T Match<T>(Func<T> success, Func<E, T> failure) => failure(Item);
            public override void Match(Action success, Action<E> failure) => failure(Item);
        }
    }
}
