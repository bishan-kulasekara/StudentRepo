export class Student {
  private static instance: Student;

  private _id: number;
  private _firstName: string;
  private _lastName: string;
  private _mobile?: string;
  private _email: string;
  private _nic?: string;
  private _dateOfBirth: string;
  private _address?: string;
  private _profileImage?: string;

  private constructor() {
    this._id = -1;
    this._firstName = '';
    this._lastName = '';
    this._mobile = '';
    this._email = '';
    this._nic = '';
    this._dateOfBirth = '';
    this._address = '';
    this._profileImage = '';
  }

  static getInstance(): Student {
    if (!Student.instance) {
      Student.instance = new Student();
    }
    return Student.instance;
  }

  init() {
    this._id = -1;
    this._firstName = '';
    this._lastName = '';
    this._mobile = '';
    this._email = '';
    this._nic = '';
    this._dateOfBirth = '';
    this._address = '';
    this._profileImage = '';
    return this;
  }

  get id(): number {
    return this._id;
  }

  set id(value: number) {
    this._id = value;
  }

  get firstName(): string {
    return this._firstName;
  }

  set firstName(value: string) {
    this._firstName = value;
  }

  get lastName(): string {
    return this._lastName;
  }

  set lastName(value: string) {
    this._lastName = value;
  }

  get mobile(): string | undefined {
    return this._mobile;
  }

  set mobile(value: string | undefined) {
    this._mobile = value;
  }

  get email(): string {
    return this._email;
  }

  set email(value: string) {
    this._email = value;
  }

  get nic(): string | undefined {
    return this._nic;
  }

  set nic(value: string | undefined) {
    this._nic = value;
  }

  get dateOfBirth(): string {
    return this._dateOfBirth;
  }

  set dateOfBirth(value: string) {
    this._dateOfBirth = value;
  }

  get address(): string | undefined {
    return this._address;
  }

  set address(value: string | undefined) {
    this._address = value;
  }

  get profileImage(): string | undefined {
    return this._profileImage;
  }

  set profileImage(value: string | undefined) {
    this._profileImage = value;
  }
}
