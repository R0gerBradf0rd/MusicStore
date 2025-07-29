﻿namespace MusicStore.Application.Interfaces.Result
{
    public class Result<T>
    {
        public bool IsSuccess { get; }

        public bool IsError => !IsSuccess;

        public string Error { get; }

        public T? Value { get; }

        protected Result( bool isSuccess, T value, string error )
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result<T> Success( T value ) => new Result<T>( true, value, null );

        public static Result<T> Failure( string error ) => new Result<T>( false, default, error );
    }
}
