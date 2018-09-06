export class RegisterUser {
    constructor(
        public username: string = '',
        public email: string = '',
        public password: string = '',
        public confirmPassword: string = ''
    ) { }

    // another way
    // constructor(
    //     public username?: string,
    //     public email?: string,
    //     public password?: string,
    //     public confirmPassword?: string
    // ) { }
}