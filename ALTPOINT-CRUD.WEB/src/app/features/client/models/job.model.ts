import { JobTypes } from "../enums/job-types.enum";
import { Address } from "./address.model";

export interface Job {
    id: string;
    createdAt: string | null;
    updatedAt: string | null;
    isDeleted: boolean | null;
    deleteadAt: string | null;
    type: JobTypes | null;
    dateEmp: string | null;
    dateDismissal: string | null;
    monIncomde: number;
    tIN: string;
    factAddress: Address | null;
    jurAddress: Address | null;
    phoneNumber: string | null;
}