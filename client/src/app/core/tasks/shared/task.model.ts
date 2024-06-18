export interface Task extends NewTask {
    id: number;
    checked: boolean;
}

export interface NewTask {
    title: string;
}