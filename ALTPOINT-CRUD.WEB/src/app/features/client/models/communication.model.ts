import { CommunicationTypes } from "../enums/communication-types.enum";


export interface Communication {
    id: string;
    type: CommunicationTypes;
    value: string;
}