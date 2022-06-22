export interface Pagination<T> {
    limit: number;
    page: number;
    total: number;
    data: T[];
}