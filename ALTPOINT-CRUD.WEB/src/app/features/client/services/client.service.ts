import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Pagination } from "../../paginator/models/pagination.model";
import { Client } from "../models/client.model";
import { environment } from "src/environments/environment";
import { GetPaginationDto } from "../../paginator/dtos/get-pagination.dto";

@Injectable({providedIn:'root'})
export class ClientService
{
    private baseEndpoint = `${environment.API_URL}clients`;

    constructor(private http:HttpClient) { }

    getPagination(dto:GetPaginationDto): Observable<Pagination<Client>>
    {
        let query = `page=${dto.page}&limit=${dto.limit}`;
        query += dto.sortBy ? `&sortBy=${dto.sortBy}` : '';
        query += dto.sortDir ? `&sortDir=${dto.sortDir}` : '';
        query += dto.search ? `&search=${dto.search}` : '';
        
        return this.http.get<Pagination<Client>>(`${this.baseEndpoint}?${query}`);
    }

    create(client:Client): Observable<Client>
    {
        return this.http.post<Client>(`${this.baseEndpoint}`, client)
    }

    update(client:Client): Observable<Client>
    {
        return this.http.patch<Client>(`${this.baseEndpoint}/${client.id}`, client)
    }

    delete(client:Client): Observable<Client>
    {
        return this.http.delete<Client>(`${this.baseEndpoint}/${client.id}`)
    }
}