import { Type } from 'class-transformer';
import 'reflect-metadata';
import LogMessage from './logmessage';

export default class Span {
    spanIdentifier: string;
    requestUrl: string;
    traceIdentifier: string;
    @Type(() => Span)
    childSpans: Span[];
    logs: LogMessage[];
    inProgress: boolean;
    hostname: string;
    applicationName: string;

    constructor(spanIdentifier: string, requestUrl: string, traceIdentifier: string, hostname: string, applicationName: string) {
        this.spanIdentifier = spanIdentifier;
        this.requestUrl = requestUrl;
        this.traceIdentifier = traceIdentifier;
        this.childSpans = [];
        this.logs = [];
        this.inProgress = true;
        this.hostname = hostname;
        this.applicationName = applicationName;
    }

    get childrenCount(): number {
        let count = 0;
        this.childSpans.forEach(element => {
            count += element.childrenCount + 1;
        });

        return count;
    }

    get logChildrenCount(): number {
        let count = 0;
        count = count + this.logs.length;
        this.childSpans.forEach(element => {
            count += element.logChildrenCount;
        });

        return count;
    }
}