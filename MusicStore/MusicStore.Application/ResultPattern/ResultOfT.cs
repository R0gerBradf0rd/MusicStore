﻿namespace MusicStore.Application.ResultPattern
{
    public class Result<T> : Result
    {
        public T? Value { get; set; }

        protected Result( bool isSuccess, T value, string error )
            : base( isSuccess, error )
        {
            Value = value;
        }

        public static Result<T> Success( T value ) => new Result<T>( true, value, null );

        public static Result<T> Failure( string error ) => new Result<T>( false, default, error );
    }
}
