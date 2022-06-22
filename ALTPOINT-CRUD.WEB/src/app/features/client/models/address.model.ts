export interface Address {
    id: string;
    createdAt: string | null;
    updatedAt: string | null;
    isDeleted: boolean | null;
    deleteadAt: string | null;
    zipCode: string | null;
    country: string | null;
    region: string | null;
    city: string | null;
    house: string | null;
    apartment: string | null;
}