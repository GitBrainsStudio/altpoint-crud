import { EducationTypes } from "../enums/education-types.enum";
import { Address } from "./address.model";
import { Child } from "./child.model";
import { Communication } from "./communication.model";
import { Job } from "./job.model";
import { Passport } from "./passport.model";

export interface Client {
    id: string;
    createdAt: string | null;
    updatedAt: string | null;
    isDeleted: boolean | null;
    deleteadAt: string | null;
    name: string | null;
    surname: string | null;
    patronymic: string | null;
    dob: string | null;
    children: Child[];
    documentIds: string[];
    passport: Passport | null;
    livingAddress: Address | null;
    jobs: Job[];
    curWorkExp: number;
    typeEducation: EducationTypes;
    monIncome: number;
    monExpenses: number;
    communications: Communication[];
}