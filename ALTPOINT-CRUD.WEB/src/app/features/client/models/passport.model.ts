export interface Passport {
    id: string;
    createdAt: string | null;
    updatedAt: string | null;
    isDeleted: boolean | null;
    deleteadAt: string | null;
    series: string;
    number: string;
    giver: string;
    dateIssued: string;
}