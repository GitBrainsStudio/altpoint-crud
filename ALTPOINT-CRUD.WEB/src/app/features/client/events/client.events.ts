import { EventEmitter, Injectable } from "@angular/core";
import { Client } from "../models/client.model";

@Injectable({providedIn:'root'})
export class ClientEvents
{
    public updated$ = new EventEmitter<Client>();
    public created$ = new EventEmitter<Client>();
}