export interface Task extends NewTask {
    id: number;
    isCompleted: boolean;
}

export interface NewTask {
    title: string;
}