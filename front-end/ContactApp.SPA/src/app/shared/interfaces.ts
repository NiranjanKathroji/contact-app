// Defining Typescript models which matches API view models.
export interface IUser {
    id: number;
    name: string;
    gender: string;
    email?: string;
    phoneNumber?: number;
    contactPreference: string;
    dateOfBirth: Date;
    department: string;
    isActive: boolean;
    photoPath?: string;
}

export interface IEnquiry {
    id?: number;
    CustomerId?: number;
    title: string;
    message: string;
    customer: ICustomer;
}

export interface ICustomer {
    id?: number;
    userName: string;
    firstName: string;
    lastName?: string;
    gender: string;
    email?: string;
    avatar: string;
    enquiries: IEnquiry[];
}
