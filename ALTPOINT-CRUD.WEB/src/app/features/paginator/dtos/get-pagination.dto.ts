import { SortDirectionType } from "../enums/sort-direction-type.enum";

export interface GetPaginationDto {
    page: number;
    limit: number;
    sortBy: string | null;
    sortDir: SortDirectionType;
    search: string | null;
}